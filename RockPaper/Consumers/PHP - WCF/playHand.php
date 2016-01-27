<?php
include("hosts.php");
header('Content-Type: application/json');

$functionName = $_GET['functionName'];
$teamId = $_GET['teamId'];
$gameId = $_GET['gameId'];

$hand = Rock;

switch ($functionName)  {
	case 'playHand':
		/* INSERT YOUR LOGIC HERE
		
		
		
		*/
		$client = new SoapClient($WDSLurl);
		$result = $client->PlayHand(array('gameId' => $gameId,
										  'teamId' => $teamId,
										  'hand' => $hand));
		break;
	default:
	  
	   break;
}

echo json_encode($result);

?>