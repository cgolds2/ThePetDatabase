<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With"); 

// include required files
include_once 'db.php';
include_once 'shelter.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$shelter = new Shelter($conn);

$json = file_get_contents("php://input");
$data = json_decode($json, true);

$shelter->name = $data['name'];
$shelter->address = $data['address'];
$shelter->website = $data['website'];
$shelter->phone_number = $data['phone_number'];
$shelter->admin_id = $data['admin_id'];

if ($shelter->create()) {
    echo 1;
    return 1;
} else {
    echo -1;
    return -1;
}

?>
