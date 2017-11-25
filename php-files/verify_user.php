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
$stmt = $user->get_user();
$num = $stmt->rowCount();

// check if more than 0 record found
if ($num > 0) {
    // retrieve table contents
    $row = $stmt->fetch(PDO::FETCH_ASSOC);
    // extract row
    extract($row);
    // verify password
    if (password_verify($data['password'], $row['password_hash'])) {
        $users = array(
            "id" => $row['id'],
            "username" => $row['username'],
            "password_hash" => $row['password_hash'],
            "shelter_id" => $row['shelter_id'],
            "email" => $row['email']
        );
        echo json_encode($users);
        return 1;
    } else {
        echo json_encode(
                array("error" => "Incorrect username or password.")
        );
    }
} else {
    echo json_encode(
            array("error" => "Incorrect username or password.")
    );
}
return -1;

?>
