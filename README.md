# Ebix Extract

This program can unpack .ebix downloaded EBook package for [EBookJapan](https://www.ebookjapan.jp) with DRM.

## Requirement

Windows

.Net Framework 4.7.2

## Build

See make.bat

## Usage

Download .ebix with [ebiReader](https://www.ebookjapan.jp/ebj/guide/app-connect/windows/), default download path is `Documents\EBJ\ebookjapan\Books`.

Run this program with `main.exe EBIX_PATE [OUTPUT_DIR]` then find all jpg in the output dir (default in the dir with same name as .ebix)

## Notice

This program can only run on machine which download the .ebix (There's a machine check with DRM).

You can't Extract a `.ebix` from others.

Only tested .ebix with `"HVQBOOK4.00"` header, not known(seen) what about others.

## How it works

It just call the official dll function to Extract.
