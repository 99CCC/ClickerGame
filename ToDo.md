## DOING
- 3. Percentage Logic (more thought through scaling for cost & power)
- 5. Switching Button to a Png
- 6. Wireframe
	- 6.5 Write down tasks from wireframe
- 7. Clean up scenes and files
	7.5 Structur for Labels and Cookie (separate concerns)

## Features
- Label: Name of Bakery
- Label: Counter of Clicks
	Func: Yes
- Label: Total CPS
	Func: Yes
- 2DSprite: Cookie
	Func: Yes (missing animation)
- Animated 2DSprite?: Milk
- TextureButton: Options
- TextureButton: Stats
- TextField: RNG messages
- TextureButton: Info
- TextureButton: Legacy
- Label: Store Title
- VBox: Upgrades
- window?: Purchase/sell toggle + quantity
- VBox: UpgradePanel **Refactor it to buildingPanel
	-Func: Yes
	
## FUTURE IDEAS
- a. Random Click Events ie the golden cookie
- b. Settings tab
- c. volume control/add a dummy soundtrack
- d. figure out respone windows
- e. Add in float or percentage increase logic (might be able to do with just int and percentage calcs)
- f. UML: Unified Modelling Language
- g. WBS: Work Breakdown Structure Diagram
- h. Save States: 3 Save Slots

## DONE
- 1. Set up a running main.cs that pops up a window (tscn) -DONE
- 3. Refactor: Singleton & Feature based design
- 4. Need to set the text of the upgradePanel on Ready (to correct costs)
- 5. Refactor the logic for upgrades, to not be 10 functions doing the same stuff
		-param becomes type of Item and then we check Item.id or name
- 7. Add RemoveClicks Function Logic
- 6. Add a new label on the Click Object representing the CPS
- 2. (Maybe off stream) Set up version control (Git)
- 4. Scrollbar for the upgradePanel
	- 5.5. Make a clickable png/sprite
