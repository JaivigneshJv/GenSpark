# Database Design and ER Modelling 

## Overview

This repository is dedicated to solving problems related to database design and Entity-Relationship (ER) modelling. The tasks for the day include designing a database for a shop and creating an ER model for a movie store.

## Tasks

### 1. Database Design for a Shop

Design a database for a shop that sells products. The database should consider the following points:

1. One product can be supplied by many suppliers.
2. One supplier can supply many products.
3. All customer details have to be present.
4. A customer can buy more than one product in every purchase.
5. The bill for every purchase has to be stored.

Note: The shop details do not need to be stored.

![ShopERD](./Assets/diagram-export-30-04-2024-16_19_32.png)

### 2. ER Modelling for a Movie Store

Create an ER model for a movie store with the following specifications:

1. A video store rents movies to members.
2. Each movie in the store has a title and is identified by a unique movie number.
3. A movie can be in VHS, VCD, or DVD format.
4. Each movie belongs to one of a given set of categories (action, adventure, comedy, etc.)
5. The store has a name and a unique phone number for each member.
6. Each member may provide a favorite movie category (used for marketing purposes).
7. There are two types of members: Golden Members and Bronze Members.
8. Golden Members can rent one or more movies using their credit cards, while Bronze Members can rent a maximum of one movie.
9. A member may have a number of dependents (with known names), each of whom is allowed to rent one movie at a time.

![MovieERD](./Assets/diagram-export-30-04-2024-16_19_13.png)

