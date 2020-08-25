This readme focuses on using the config.json file. Note that you do not have to do anything with this because the mod will generate a default config file with the "horizontal" spray pattern.

1. THE EXAMPLE CONFIG

In the mod package is a file called "config-example-CHANGE-ME.json" which you can use as your initial config file. It contains the following:

{
  "_comment":  "Remove this line and change the file name to config.json, see readme.txt for usage instructions.",
  "patternType": "horizontal",
  "northArea": 0,
  "southArea": 0,
  "eastArea": 2,
  "westArea": 2
}

With the exception of the "_comment" key, this is identical to the default conifg.json the mod will generate. To use this file, completely remove the line with "_comment" so that "patternType" is the first entry in the brackets, then rename the file to "config.json"

It can be used as it after that point, or modified according to these instructions.

2. CONFIGURATION INSTRUCTIONS

The mod works by watering tiles according to one of the following configurations. (The X represents the sprinkler and the Os the tiles it waters while each * represents an unwatered tile.)

horizontal: 

*****
*****
OOXOO
*****
*****

vertical:

**O**
**O**
**X**
**O**
**O**

north:

**O**
**O**
**O**
**O**
**X**

south:

**X**
**O**
**O**
**O**
**O**

east:

*****
*****
XOOOO
*****
*****

west:

*****
*****
OOOOX
*****
*****

The config.json file by default makes the mod use the "horizontal" configuration. To change that, change the "patternType" item. The valid types are: "horizontal", "vertical", "north", "south", "east", "west", and "custom", which deserves more explanation.

The four items in the config.json called "northArea", "southArea", "eastArea", and "westArea" define possible alternative configurations. You need to set the "patternType" to "custom" for this to work. Then you need to provide values. Whatever value you put in the appropriate direction is how many tiles it will water in that direction. However, it won't let you water more than 4 tiles total.

For example, with this configuration:

"patternType": "custom",
"northArea": 1,
"southArea": 1,
"eastArea": 2,
"westArea": 0
  
The sprinkler will produce this pattern:

*****
**O**
**XOO
**O**
*****

If you don't set the "patternType" to "custom" then the numbers will be ignored entirely.

Changes to config.json will only take effect after restarting the game.