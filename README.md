Lucidity
========

Lucidity is a flexible log parsing system that aims to make reading log files easier.  The project was born out of frustration of trying to track down bugs in a system by reading NLog trace logs.  

Lucidity has three main components

Lucidity.Engine
---------------

This is the core engine that powers log parsing with Lucidity.  Log parsing deals with two primary interfaces:

* ILogParser
* ILogStore

A log parser takes a logging source and attempts to split the log into individual records, and split each record into individual fields.  The parser then passes the records to the specified log storage engine.  After that queries can be run against the log storage by creating specific inclusive and exclusive filters.

The parsers and stores are plugins loaded via the Managed Extensibility Framework.  

The project currently contains 1 parser (pipe delimited log parser) and 2 log stores (in memory storage and storage in RavenDB).

Lucidity.Winforms
-----------------

This is the winforms project to parse a log and apply filters to the log.  This enables easy viewing of a log file.


Lucidity.Web
------------

This is a (not yet created) project to create a web-based log parsing system.  Parsing in a web-based environment will allow users to upload a log, apply filters to the log, and give a specific URL to a coworker or friend so everyone can look at the exact same log entries at the same time without everyone having to filter log files themselves.   