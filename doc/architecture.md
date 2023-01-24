[[_TOC_]]

Structure based on the [arc42](https://arc42.org/overview/) template.
I also reference terminology from [Simon Browns C4 model](https://c4model.com/), which I tag with `C4`.

# 1 Introduction and Goals

The Toy Robot Simulator is a simple command line tool which simulates a robot on a table top responding to basic movement and directional commands. It was built based on a task given during the Telstra Purple interview process.
There is no explicit context or long-term goal for this software. The assumption has been made that this is simply to demonstrate basic coding ability.

I include this architecture doc since it is a template I use for more complex applications and services. Even for simple tasks it can serve as a reminder not to skip over relevant parts, or to note why something has NOT been done.

# 2 Constraints

See explicit requirement constraints layed out in the [task-description.md](./task-description.md) file.

## 2.1 Assumptions

Because of the bare-bones state of the requirements, the following assumptions were made:

1. The user is well versed in using the application. They know the commands and the expected behaviour of the application. Given this, detailed validation / error messaging was ommitted to save time.

# 3 Context and Scope

There is no explicit context given other than the immediate requirements.

# 4 Solution Strategy

Based on the requirement "clean and easy to read, maintain and execute", the strategy is to keep the solution as simple as possible while keeping the code readable and relatively easy to maintain / extend.

# 5 Building Block View

## 5.1 C4: Container View

Not necessary at this stage.

## 5.2 C4: Component View

Not necessary at this stage.

# 6 Runtime View

Not necessary at this stage.

# 7 Deployment View

Not necessary at this stage.

# 8 Crosscutting Concepts

Not necessary at this stage.

# 9 Architectural Decisions

| Id  | What                          | Why                                                                  | When       | Who |
| --- | ----------------------------- | -------------------------------------------------------------------- | ---------- | --- |
| AD1 | No separate validator classes | Validation logic is still simple enough to keep it in the controller | 23/01/2023 | Ben |

# 10 Quality Requirements

See requirements layed out in the [task-description.md](./task-description.md) file.

# 11 Risks and Technical Debt

## 11.1 Risks

Not required for now.

## 11.2 Technical Debts

| Id  | Technical Debt | Reasoning at time of decision | Impact if not cleaned up | Mitigations |
| --- | -------------- | ----------------------------- | ------------------------ | ----------- |
| -   | -              | -                             | -                        | -           |

# 12 Glossary

Not necessary at this stage.
