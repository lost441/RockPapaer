<?php
include("hosts.php");
header('Content-Type: application/json');


$functionName = $_GET['functionName'];
$teamId = $_GET['teamId'];
$gameId = $_GET['gameId'];
$useSimulator = $_GET['useSimulator'];


switch ($functionName)  {
	case 'FindAGame':
		$client = new SoapClient($WDSLurl);
		$result = $client->GetNextAvailableGame(array('teamId'=> $teamId , 
													  'useSimulator' => $useSimulator));
	   break;
	case 'IsItMyTurn':
		$client = new SoapClient($WDSLurl);
		$result = $client->IsItMyTurn(array('gameId' => $gameId,
													  'teamId' => $teamId));
	default:
	   break;
}

echo json_encode($result);

?>