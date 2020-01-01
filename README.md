## IMPORTANT: THIS SYSTEM IS NOT TESTED YET AND IS IN DEVELOPMENT
# CraftSystem
A craft system that can be used in games made with unity. You can use it in strategy games, survival games and any other game that needs a system to manage recipes and the carft part of it.
## Usage
Download or clone the repo and add scripts to your unity project. create `Rosources/CraftData` directory in the Assets of your game. Add your recipes in the following format to the array in `Recipes.json` file:
```
{
  "Name": "Name of item",
  "CraftTime": Craft time in seconds,
  "Ingredients": {
    "Ingredient1": Quantity,
    "Ingredient2": Quantity,
    ...
  }
}
```
You can add other data to your recipes as you desire, But you have to implement the proper logic in `Core\CraftManager.cs`.
### Directories
`Core`: Contains main scripts that makes craft system work.  
`Example`: Contains example codes to implement basic inventory and item in order to test the system. you can replace them with your own code or use it as a code base.  
`ExternalLibraries`: Contains libraries used in system.  
`Test`: Contains a script that is responsible to test the system functionalities. [It's still in development]
## Used libraries
This system is developed using [mtschoen's JSONObject](https://github.com/mtschoen/JSONObject).
