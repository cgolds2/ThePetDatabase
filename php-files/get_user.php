<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// include required files
include_once 'db.php';
include_once 'user.php';

// create new database connection
$database = new Db();
$conn = $database->getConnection();

$user = new User($conn);

$id_param = filter_input(INPUT_GET, 'id', FILTER_SANITIZE_STRING);
if ($id_param != null) {
    $user->shelter_id = $id_param;
    $stmt = $user->read_id();
} else {
    return -1;
}
$num = $stmt->rowCount();

// check if more than 0 record found
if ($num > 0) {
    // department array
    $user_arr = array();
    $user_arr["users"] = array();

    // retrieve table contents
    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        // extract row
        extract($row);
        $users = array(
            "id" => $row['id'],
            "username" => $row['username'],
            "password_hash" => $row['password_hash'],
            "shelter_id" => $row['shelter_id'],
            "email" => $row['email']
        );
        array_push($user_arr["users"], $users);
    }
    echo json_encode($user_arr);
} else {
    echo json_encode(
            array("error" => "No users found for given shelter.")
    );
}

?>
