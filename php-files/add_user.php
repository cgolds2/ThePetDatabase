<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With"); 

// include required files
include_once 'db.php';
include_once 'user.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$user = new User($conn);

$json = file_get_contents("php://input");
$data = json_decode($json, true);

$user->username = $data['username'];
$user->shelter_id = $data['shelter_id'];
$user->email = $data['email'];

$password = $data['password'];
$user->password_hash = password_hash($password, PASSWORD_DEFAULT);
//echo $user->name;
//echo $user->address;

if ($user->create()) {
    echo '{';
    echo '"message": "Shelter was successfully added to database."';
    echo '}';
    return 1;
} else {
    echo '{';
    echo '"message": "Error adding shelter to database."';
    echo '}';
    return -1;
}

?>
