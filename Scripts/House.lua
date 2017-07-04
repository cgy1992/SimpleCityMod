import 'System' 
import 'UnityEngine'

buildItem:Init();
--buildItem:LoadDisplayImage("");

local addAmount = 500;

buildItem.BuildCost = 500;
buildItem.DisplayName = "House";
buildItem.ModelPath = "housemodel.obj";
buildItem.Scale = Vector3(69,1,1) 

function OnStart()
	--Debug.Log("Start")
end 

function OnUpdate()
	--Debug.Log("Update")
end 

function OnNextRound()
	GameManager.money = GameManager.money + addAmount
	Debug.Log("Now you have " .. GameManager.money)
end