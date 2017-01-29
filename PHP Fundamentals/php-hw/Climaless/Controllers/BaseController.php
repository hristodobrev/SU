<?php
class BaseController {
    function __construct()
    {

    }

    function redirectToUrl($url) {
        header('Location:' . $url);
        die;
    }
}