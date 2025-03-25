# OC-Rendus-P7
# Findexium - PostTrades

## Description

Ce projet est un exercice scolaire dans le cadre de la formation **OpenClassrooms**. Il s'agit d'un projet fictif visant à mettre en pratique le développement d'une API sécurisée avec ASP.NET Core.

PostTrades est une application destinée à simplifier la communication et l'utilisation des informations post-transaction entre le front et le back-office pour les entreprises institutionnelles à revenu fixe.

## Technologies utilisées

- **ASP.NET Core**
- **Entity Framework Core**
- **API Web**
- **JWT Authentication**
- **Serilog** (pour la journalisation)
- **Swagger** (pour la documentation de l'API)
- **xUnit** (pour les tests unitaires)

## Scénario

Vous avez été embauché en tant que développeur junior chez **Findexium**, un leader dans le domaine de la finance.

Affecté au groupe **Trésorerie et marchés financiers**, vous travaillez sur **PostTrades**, une application permettant d'améliorer la gestion des transactions post-marché.

Suite au départ de Stéphanie, une développeuse du projet, vous reprenez ses missions :
- Corriger et implémenter les fonctionnalités de l'application.
- Utiliser **ASP.NET Core**, **API Web**, **Entity Framework** et **API Web Security**.
- Implémenter l'authentification JWT pour sécuriser l'API.

## Installation et exécution

### Prérequis
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server ou un autre fournisseur de base de données compatible
- Un éditeur de code comme [Visual Studio](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### Étapes d'installation

1. **Cloner le projet**
   ```sh
   git clone https://github.com/votre-utilisateur/findexium-posttrades.git
   ```

2. **Configurer la base de données**
   - Modifier la chaîne de connexion dans `appsettings.json`.
   - Appliquer les migrations :
     ```sh
     dotnet ef database update
     ```
     
**Remarque** : à la création, la base de données est automatiquement crée et peuplée avec des données fictives pour faciliter les tests.

3. **Lancer l'application**
   ```sh
   dotnet run
   ```

4. **Accéder à la documentation Swagger**
   - Ouvrir : `http://localhost:5000/swagger`

## Fonctionnalités principales

- Authentification et gestion des utilisateurs avec **JWT**
- API REST pour la gestion des transactions
- Sécurisation des endpoints
- Documentation avec **Swagger**
- Gestion des logs avec **Serilog**
- **Données pré-remplies** : à la création, la base de données est automatiquement peuplée avec des données fictives pour faciliter les tests.
- **Utilisateur administrateur** : Un utilisateur avec un rôle administrateur est créé automatiquement. Vous pouvez retrouver son login et son mot de passe dans `Program.cs`.
- **Projet de tests unitaires** : Un projet de tests est inclus, couvrant les couches **Controller** et **Service** avec des tests unitaires utilisant **xUnit**.

## Remarque

🚨 **Ce projet est un exercice dans le cadre de la formation OpenClassrooms. Toutes les données et entités sont fictives.**

## Auteur

- **Grégoire Bouteillier**

