# Ebix Extract

This program can unpack .ebix downloaded EBook package for [EBookJapan](https://www.ebookjapan.jp) with DRM.

## Requirement

Windows

.Net Framework 4.7.2

## Build

See make.bat

## Usage

Download .ebix with [ebiReader](https://www.ebookjapan.jp/ebj/guide/app-connect/windows/), default download path is `Documents\EBJ\ebookjapan\Books`.

Run this program with `main.exe EBIX_PATH [OUTPUT_DIR]` then find all jpg in the output dir (default in the dir with same name as .ebix)

## Notice

This program can only run on machine which download the .ebix (There's a machine check with DRM).

You can't Extract a `.ebix` from others.

Only tested .ebix with `"HVQBOOK4.00"` header, not known(seen) what about others.

## How it works

It just call the official dll function to Extract.

## What if this program didn't work

You can try to download a new version [ebiReader](https://ebookjapan.yahoo.co.jp/app/windows/index.html) and get it's new dll replace these three old.

But remember, official dll with this program can only extract bmp image (thought filename is .jpg). Though bmp is enough for some place, you have to patch it to get real raw jpg image,

## How to patch the dll

see [#5](https://github.com/y2361547758/EbixExtract/issues/5)
