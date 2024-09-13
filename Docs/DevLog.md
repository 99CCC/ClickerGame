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
