import 'System' 
import 'UnityEngine'

buildItem:Init();
buildItem:LoadDisplayImage("C:/Users/Marcus/Desktop/SEXYBOII.png");

local addAmount = 500;

buildItem.BuildCost = 500;
buildItem.DisplayName = "House";

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