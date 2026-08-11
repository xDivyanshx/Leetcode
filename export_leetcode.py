#!/usr/bin/env python3
"""Export your accepted LeetCode submissions into one file per problem.

Defaults to C# (.cs). See README.md for how to grab your session cookie.

Usage:
    # Windows PowerShell
    $env:LEETCODE_SESSION="...your cookie..."
    python export_leetcode.py

    # Windows cmd
    set LEETCODE_SESSION=...your cookie...
    python export_leetcode.py

Optional flags:
    --lang   language slug to export (default: csharp)
    --all    keep every accepted submission, not just the latest per problem
    --out    output folder (default: solutions)
"""
import argparse
import json
import os
import re
import sys
import time
from pathlib import Path

import requests

API = "https://leetcode.com/api/submissions/"
GRAPHQL = "https://leetcode.com/graphql"
CACHE_FILE = ".leetcode_cache.json"

EXT = {"csharp": "cs", "python3": "py", "python": "py", "java": "java",
       "cpp": "cpp", "c": "c", "javascript": "js", "typescript": "ts",
       "golang": "go", "rust": "rs", "kotlin": "kt", "swift": "swift",
       "ruby": "rb", "scala": "scala", "php": "php"}


def load_cache():
    try:
        return json.loads(Path(CACHE_FILE).read_text())
    except Exception:
        return {}


def make_session(cookie, csrf):
    s = requests.Session()
    s.headers.update({
        "User-Agent": ("Mozilla/5.0 (Windows NT 10.0; Win64; x64) "
                       "AppleWebKit/537.36 (KHTML, like Gecko) "
                       "Chrome/122.0 Safari/537.36"),
        "Referer": "https://leetcode.com/submissions/",
        "x-requested-with": "XMLHttpRequest",
    })
    s.cookies.set("LEETCODE_SESSION", cookie)
    if csrf:
        s.cookies.set("csrftoken", csrf)
        s.headers["x-csrftoken"] = csrf
    return s


def fetch_submissions(s):
    offset, limit = 0, 20
    while True:
        r = s.get(API, params={"offset": offset, "limit": limit})
        if r.status_code == 403:
            sys.exit("403 Forbidden - LEETCODE_SESSION is missing, expired, "
                     "or blocked. Grab a fresh cookie and retry.")
        r.raise_for_status()
        data = r.json()
        for sub in data.get("submissions_dump", []):
            yield sub
        if not data.get("has_next"):
            break
        offset += limit
        time.sleep(1.0)


def question_meta(s, slug, cache):
    if slug in cache:
        return cache[slug]
    query = ("query q($titleSlug: String!){question(titleSlug:$titleSlug)"
             "{questionFrontendId difficulty title}}")
    try:
        r = s.post(GRAPHQL, json={"query": query,
                                  "variables": {"titleSlug": slug}}, timeout=20)
        q = r.json()["data"]["question"]
        meta = {"id": q["questionFrontendId"], "difficulty": q["difficulty"],
                "title": q["title"]}
    except Exception:
        meta = {"id": "0000", "difficulty": "Unknown", "title": slug}
    cache[slug] = meta
    time.sleep(0.3)
    return meta


def sanitize(name):
    return re.sub(r"[^A-Za-z0-9._-]", "-", name)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--lang", default="csharp")
    ap.add_argument("--all", action="store_true")
    ap.add_argument("--out", default="solutions")
    args = ap.parse_args()

    cookie = os.environ.get("LEETCODE_SESSION")
    if not cookie:
        sys.exit("Set LEETCODE_SESSION first. See README.md for how to get it.")
    csrf = os.environ.get("LEETCODE_CSRF", "")

    ext = EXT.get(args.lang, "txt")
    cmt = "#" if ext in ("py", "rb") else "//"
    out = Path(args.out)
    out.mkdir(parents=True, exist_ok=True)
    cache = load_cache()
    s = make_session(cookie, csrf)

    seen, written = set(), 0
    print(f"Fetching submissions, keeping accepted {args.lang} (.{ext})...")
    for sub in fetch_submissions(s):
        if sub.get("status_display") != "Accepted" or sub.get("lang") != args.lang:
            continue
        slug = sub["title_slug"]
        if not args.all and slug in seen:
            continue
        seen.add(slug)

        meta = question_meta(s, slug, cache)
        num = str(meta["id"]).zfill(4)
        base = f"{num}-{sanitize(slug)}"
        if args.all:
            base += f"-{sub['id']}"
        fpath = out / f"{base}.{ext}"

        when = time.strftime("%Y-%m-%d", time.localtime(sub["timestamp"]))
        header = (
            f"{cmt} {meta['id']}. {meta['title']}\n"
            f"{cmt} Difficulty: {meta['difficulty']}\n"
            f"{cmt} https://leetcode.com/problems/{slug}/\n"
            f"{cmt} Runtime: {sub.get('runtime', '?')} | "
            f"Memory: {sub.get('memory', '?')} | Submitted: {when}\n\n"
        )
        fpath.write_text(header + sub.get("code", ""), encoding="utf-8")
        written += 1
        print(f"  {fpath.name}")

    Path(CACHE_FILE).write_text(json.dumps(cache, indent=2))
    print(f"\nDone. Wrote {written} file(s) to {out.resolve()}")


if __name__ == "__main__":
    main()
