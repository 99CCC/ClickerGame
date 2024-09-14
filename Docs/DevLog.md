## 14.09.2024
We managed to fix the bug with the clickpower not updating, altough
we didnt find the root cause for the CPS acting up.
Issue is that the value of the totalCPS gets set to 12 after 2 upgrades,
but its only possible to buy the item Moneyprinter, which would 
give you 8 power meaning you should only have 8 CPS.
The bug about the timer being too fast also seems to be there,
but this might just be a symptom of the totalCPS not being assigned
the correct value.
BuildingPanel = 8
CounterContainer = 12
CpsContainer = 12

## 13.09.2024
We managed to fix the for loop logic and have a working-ish dictionary
only problem is that said dictionary lead the CounterCointainers functions
to not work as expected, they print out the correct item.Power,
but the ClickPower/Mouse clicking never yields any higher power in function.
Another weird thing, is that the CPS seems to be added faster than 1 sec,
but again in print it shows up as expected Power. 
The Timer seems to be 3 ticks per second (i.e CPS = 4, gives 12 CPS)

## 12.09.2024
Issues with the new setup for the buildingpanel,
the buildingpanel logic itself is pretty close to correct,
but we need to figure out a way to do pretty much the same for the
item objects within the code (meaning not the visual items).
+We need to add a method either in GameManager/Main or in the abstract
Item class if possible that returns the instance of an item which can
then be used in the:
		buildingName = list that gets filled from CSV[i];
		res = GameManager.Instance.GetInstanceOf(buildingName);
		button.pressed += () => purchaseUpgrade(res);
