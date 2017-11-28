<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With"); 

// include required files
include_once 'db.php';
include_once 'picture.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$picture = new Picture($conn);

$pet_id = filter_input(INPUT_GET, 'id', FILTER_SANITIZE_STRING);
if ($picture == null) {
    echo -1;
    return -1;
}

$picture->id = $pet_id;

if ($picture->delete()) {
    echo 1;
    return 1;
} else {
    echo -1;
    return -1;
}

?>
