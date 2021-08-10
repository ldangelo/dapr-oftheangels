# Introduction

Test project used to learn the varios features of dapr.  Additionally it is used
as a proving ground for a gitops workflow.

# Architecture

## UserService

The UserService is an API Server implemented using CQRS and Dapr.  It utilizes
Dapr for state storage (Redis) and events (Redis).
## Projector

The Projector is a console service that listens for Dapr events and projects the
state into a Postgres database for reporting and analytics.

## Infrastructure
### Redis
### Postgres


