<?php
include("hosts.php");

header('Content-Type: application/json');

$functionName = $_GET['functionName'];
$teamName = $_GET['teamName'];	

switch ($functionName)  {
	case 'findATeam':
		$client = new SoapClient($WDSLurl);
		$result = $client->GetTeamByTeamName($teamName);
	   break;
	case 'registerTeam':
		$client = new SoapClient($WDSLurl);
		$result = $client->RegisterTeam($teamName);
		break;
	default:
	  
	   break;
}

echo json_encode($result);

?>