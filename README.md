# Answery
Answery is an application which idea is to provide a way anonymously to ask and receive answers from other people.


-@-
 The main idea of the project is to provide a way for users to ask questions anonymously. They do not need even to be registered users in order to ask questions. Everyone can ask questions. However, if someone wants his asked questions to be saved in case he wants to see them in some time later, he is able to register in the application. Moreover, registration provides a way to have your own profile in which you can customize your data and respectively see what other users have asked you. The most important thing is to have fun while using the application.

___

# Project structure:
  4 Folders:
    - Data
    - Services
    - Tests
    - Web
  
  Each folder represents different modules in the application.
  
___

## Folder 'Data'
Deals with the database of the project.
  - Contains three assemblies.
    - Data
    - Common
    - Models
  Data is used to store migrations, db context and db configuration.
  Common is used for commonly used classes, such as: Repository, BaseModel
  Models is used to represent all database models in the application.
    - Currently, there are five models: Blog, Comment, Like, Question, User
  
___

## Folder 'Services'
Used to store all services which access the database and make changes.
  Folder interfaces: Stores all interfaces that put restrictions for the services
  Services:
    - Answers Service
    - Comments Service
    - Likes Service
    - Users Service
    - Questions Service

___

## Folder 'Web'
This folder contains two projects - one for Infrastructure and one for .NET MVC part.
  Infrastructure
    Contains mappings and AutoMapper configurations
  Web
    Starter project, contains the entire back-end and front-end part of the application.
      - App_Start
          Contains configuration files for Asp.Net Identity system, routes, AutoFac IoC, Bundles and Glimpse.
      - Areas
          Contains the Blog area of the application.
      - Content
          This is a folder with static files and mostly with styles.
      - Controllers
          Contains every controller of the application.
      - Fonts
          Here are put all the fonts needed for the front part of the application.
      - Scripts
          Mostly JavaScript libraries.
      - ViewModels
          Contains all view models in the project. They are mapped from the original db models.
      - Views
          Contains all vies in the application. They are separated in named folders.

___

Project Author: Alexander Markov
Date: 2/24/2016
License: MIT
