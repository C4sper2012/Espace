<h1 align="center"> Espace </h1> <br>
<p align="center">
  </a>
</p>

<p align="center">
Espace is a web based todo app service, that allows users to create todo lists using a web api
</p>


## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Feedback](#feedback)
- [Contributors](#contributors)
- [Build Process](#build-process)
- [Acknowledgments](#acknowledgments)
- [Disclaimer](#disclaimer)
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

This project is purely for education purposes. I am not profiting from this nor have i plans to profit from it.

- [x] En Index forside (der kan fortælle lidt om projektet - og som altid vil tillade anonym adgang)
- [x] En TodoItems side der viser alle TodoItems , der ikke er udført
- [ ] Klikker man på et TodoItems Description, åbnes emnet på en ny Page. Her er mulighed for at redigere Description, Completed og Priority. Der er lavet validering af brugerdata. 
- [x] Desuden skal man kunne slette emnet og der skal gerne kræves en godkendelse inden emnet slettes.
- [x] På forsiden skal der være en mulighed for at oprette et nyt TodoItem. Der er lavet validering af brugerdata. Som en ekstra option kan man lave formen som en Modal form.
- [ ] Når man klikker på et TodoItems Checkbox for at markere at et TodoItem er udført, fjernes emnet fra forsiden (SoftDelete). Tip: Named PageHandlers
- [x] Der er lavet en TodoService, som injectes med DI
- [x] Applikationenens konstanter, som f.eks. URL's og andet er angivet i en AppConstants klasse
- [x] Der laves en ReadMe til projektet, der bl.a. markerer hvilke krav der er opfyldt
