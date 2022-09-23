Please try not to spend more than 2-4 hours on this exercise.

We love GitHub, but we also want to keep our assignments private to make sure we can reuse them,
so please don't submit your solution there - send us a ZIP file instead. Don't include the example files in the ZIP file.

PLEASE NOTE: The Delivery will be reviewed by a team of Siteimprove developers. In order to ensure that we can treat the Delivery anonymously, please make sure that the Delivery does not contain your name or other personal identifiable information.

Introduction
============

The given set of input files contains lines in the format [id]:[content]. The 'id' is an int64 and
the 'content' is a string in UTF-8 format with embedded newlines escaped as backslash n. E.g.

183271637:This is the content for the\nfirst id  
1836719631:This is some content for another id

The length of the id varies but the id and content is always separated by a colon ':'. The id
is always the first item on the lines in the files and is always a number. The text content
runs until next line break.

The files are named 0.html to 9.html. The exercise contains 10 example files in the format described.

Any id is unique across all 10 files.

The exercise
============

Scan or search through a set of text files in the format described above after a given search pattern
(in regular expression syntax). If the content of a line in an input file matches the pattern, return the id of the
matching line. Neither the name of the file, the content of the line, or the order of the resulting ids
matter.

The result should be a list of ids output on the console or returned as a JSON array.

Limitations
===========

Assume that there's no upper limit on the length of an input file.

Try to achieve optimal resource (min IO, min RAM, max CPU) utilization, by e.g. threading or other
strategies of your choice.

You choose programming language, any external libraries and strategy for implementation. You should
build a solution from scratch.

Example
=======

Here are two examples of searching through the given files for a specific search pattern:

	Pattern: Section \d+ Refresh
	Results: 9028094287,9780103281

	Pattern: Siteimprove\s+Web\s+analytics
	Results: 9131522019

