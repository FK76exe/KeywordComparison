# Keyword Comparison App

This application takes in a job description, a plain text resume, and a list of keywords to search for.
Upon pressing "Submit", the user's resume receives a score based on this formula:

```
(number of unique keywords in resume) / (number of unique keywords in job description) as a %
```

A high % means that the resume shares a lot of keywords with the job description, making a good match.
Otherwise, it's a low match.

This application was made with C# and Windows Presentation Foundation (WPF) as a learning tool.

TODO
- ✅Get keywords from the job description and use that for keyword appearance in resume
- ✅ match for full words
- ✅fix variable names
- Display missing keywords
- add/remove keywords