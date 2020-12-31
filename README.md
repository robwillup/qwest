# Quest - Work Management for Devs

`Quest` is an application for creating *tasks* straight from the command line. The tasks are saved to a Markdown file in the project's source code. This helps developers manage their work directly from their source code files. Also, the completed tasks show the project's history and evolution.

![.NET Core](https://github.com/RWillup/quest/workflows/.NET%20Core/badge.svg)

<p align="center">
  <img width=700 src="./assets/images/quest.jpg">
</p>

## How does it work?

### View commands and options:

```bash
$ quest help

Quest!

COMMANDS:
    do.............Creates a new task
    done...........Lists completed tasks
    done <GUID>....Marks the task as complete
    todo...........Lists current active tasks
    undo...........Marks a complete task as active
    dont...........Deletes a task from ToDos
    version........Displays current version
    help...........Displays information about commands and flags

Use 'quest help <COMMAND>' for more information.
```

### Create a new task:

```bash
$ quest do "write new unit test for function XYZ"
```

### List active tasks:

```bash
$ quest todo

# To Dos

* write new unit test - (2b2f3c4d-3e06-4465-88a3-6155a983583f) - Created at: 12/31/2020 12:00:02 PM
```

### Complete a task:

```bassh
$ quest done 2b2f
```

### List completed tasks:

```bash
$ quest done

* write new unit test - (2b2f3c4d-3e06-4465-88a3-6155a983583f) - Created at: 12/31/2020 12:00:02 PM - Completed at: 12/31/2020 12:01:59 PM
```
### Move a completed task back to active

```bash
$ quest undo 2b2f
```

### Delete an active task:

```bash
$ quest dont 2b2f
```
## How to Install

Download the latest version from [here](https://github.com/robwillup/quest/releases/tag/v0.0.2).

## License

Quest is licensed under the terms of the MIT license.