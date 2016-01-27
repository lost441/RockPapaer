<?php
include("hosts.php");
header('Content-Type: application/json');

$functionName = $_GET['functionName'];
$gameId = $_GET['gameId'];

switch ($functionName)  {
	case 'updateTable':
		$client = new SoapClient($WDSLurl);
		$result = $client->GetCompletedRoundByGameId(array('gameId' => $gameId));
		break;
	default:
	  
	   break;
}

echo json_encode($result);

?>