---
theme: "black"
separator: '^\r?\n---\r?\n$'
verticalSeparator: '^\r?\n--\r?\n$'
controls: false
menu: false
history: true
progress: false
slideNumber: false
mouseWheel: true
enableMenu: false
enableChalkboard: false
enableTitleFooter: false
---

# Understanding HttpClient

_by Jakub Šturc_

---

## Demo

---

## Summary

* be aware how many HttpClient you are creating
* consider lifetime ouf your HttpClients
* do not dispose, unless you know what you are doing

---

## Questions

--

### Should we dispose HttpClient?

* no, when using HttpClientFactory
* it depends no otherwise, but generally no

---

## Read more

* [Steve Gordon blog](https://www.stevejgordon.co.uk/tag/httpclient)


