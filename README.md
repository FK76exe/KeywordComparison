# Keyword Comparison App

This application takes in a job description, a plain text resume, and a list of keywords to search for.
Upon pressing "Submit", the user's resume receives a score based on this formula:

```
(number of unique keywords in resume) / (number of unique keywords in job description) as a %
```

A high % means that the resume shares a lot of keywords with the job description, making a good match.
Otherwise, it's a low match.

This application was made with C# and Windows Presentation Foundation (WPF) as a learning tool.

```
        /* TODO (2026-03-17)
         * - get keywords from job desc
         * - fill that into keyword apperance with body
         * - match full words
         * - fix variable names
         * - display missing keywords
         * - add/remove keywords
         */

```