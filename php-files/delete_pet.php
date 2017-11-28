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

$id_param = filter_input(INPUT_GET, 'id', FILTER_SANITIZE_STRING);
if ($id_param == null) {
    echo -1;
    return -1;
}

$pet->id = $id_param;

if ($pet->delete()) {
    echo 1;
    return 1;
} else {
    echo -1;
    return -1;
}

?>
