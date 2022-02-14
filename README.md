<h1 align="center"> Espace </h1> <br>
<p align="center">
  </a>
</p>

<p align="center">
Espace is a web based todo app service, that allows users to create todo lists using a web api
<br>
<a href="#disclaimer">DISCLAIMER</a>
</p>


## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Feedback](#feedback)
- [Contributors](#contributors)
- [Build Process](#build-process)
- [Acknowledgments](#acknowledgments)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Introduction

## Features

## Feedback

## Contributors

## Build Process

### Used Nuget packages
|Nuget|Version|
---|---|
|Microsoft.EntityFrameworkCore|6.0.2|
|Microsoft.EntityFrameworkCore.InMemory|6.0.2|
|Swashbuckle.AspNetCore|6.2.3|

## Acknowledgments

| API                       | Description                 | Request body | Response body        |
| ------------------------- | --------------------------- | ------------ | -------------------- |
| `GET /`                   | Browser test, "Hello World" | None         | Hello World!         |
| `GET /todoitems`          | Get all to-do items         | None         | Array of to-do items |
| `GET /todoitems/complete` | Get completed to-do items   | None         | Array of to-do items |
| `GET /todoitems/{id}`     | Get an item by ID           | None         | To-do item           |
| `POST /todoitems`         | Add a new item              | To-do item   | To-do item           |
| `PUT /todoitems/{id}`     | Update an existing item     | To-do item   | None                 |
| `DELETE /todoitems/{id}`  | Delete an item              | None         | None                 |

## Disclaimer

This project is purely for education purposes. I state again, i am not profiting from this nor have i plans to profit from it.

