﻿namespace OceanicAirlinesWebApp.Views.Login
{
    function display() {
        if ($("#txtusername").attr("value") == "") {
            alert("Please Enter your UserName.");
            return false;
        } else if ($("#txtuserpassword").attr("value") == "") {
            alert("Please enter UserPassword.");
            return false;
        }
        return true;
    }
}
