# Keyword Comparison App

This application takes in a job description, a plain text resume, and a list of keywords to search for.
Upon pressing "Submit", the user's resume receives a score based on this formula:

```
(number of unique keywords in resume) / (number of unique keywords in job description) as a %
```

A high % means that the resume shares a lot of keywords with the job description, making a good match.
Otherwise, it's a low match.

This application was made with C# and Windows Presentation Foundation (WPF) as a learning tool.

TODO as of 2026-03-29
- Remove keywords from data file
- Add keyword feature 
- View keywords resume matches and keywords it is missing
- Sort Keywords display