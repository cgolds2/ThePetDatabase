<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With"); 

// include required files
include_once 'db.php';
include_once 'petdata.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$pet = new PetData($conn);

$json = file_get_contents("php://input");
$data = json_decode($json, true);

$pet->age = $data['age'];
$pet->name = $data['name'];
$pet->notes = $data['notes'];
$pet->breed = $data['breed'];
$pet->animal_type = $data['animal_type'];
$pet->weight = $data['weight'];
$pet->shelter_id = $data['shelter_id'];
$pet->profile_picture = $data['profile_picture'];
$pet->size = $data['size'];
$pet->chip_id = $data['chip_id'];

if ($pet->create()) {
    echo '{';
    echo '"message": "Pet was successfully added to database."';
    echo '}';
    return 1;
} else {
    echo '{';
    echo '"message": "Error adding pet to database."';
    echo '}';
    return -1;
}

?>
