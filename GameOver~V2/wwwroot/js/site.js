//Shar Page


// main_submit

$("#main-submit").click(
    function () {

        if ($("#serchGameText").val().length > 0) {
            $(".SuggestNameGames").hide();
            sercgGame = lsData.filter(g => g.name.toUpperCase().includes($("#serchGameText").val().toUpperCase()));
            $(".FindGamePage .main").empty();
            if (sercgGame.length > 0) {

                sercgGame.forEach(element => {
                    $(".FindGamePage .main").append("<article class=\"card card--1\" ><div class=\"card__info-hover\" ><svg class=\"card__like\"  viewBox=\"0 0 24 24\"><path fill=\"#000000\" d=\"M12.1,18.55L12,18.65L11.89,18.55C7.14,14.24 4,11.39 4,8.5C4,6.5 5.5,5 7.5,5C9.04,5 10.54,6 11.07,7.36H12.93C13.46,6 14.96,5 16.5,5C18.5,5 20,6.5 20,8.5C20,11.39 16.86,14.24 12.1,18.55M16.5,3C14.76,3 13.09,3.81 12,5.08C10.91,3.81 9.24,3 7.5,3C4.42,3 2,5.41 2,8.5C2,12.27 5.4,15.36 10.55,20.03L12,21.35L13.45,20.03C18.6,15.36 22,12.27 22,8.5C22,5.41 19.58,3 16.5,3Z\" /></svg><div class=\"card__clock-info\">  <svg class=\"card__clock\"  viewBox=\"0 0 24 24\"><path d=\"M12,20A7,7 0 0,1 5,13A7,7 0 0,1 12,6A7,7 0 0,1 19,13A7,7 0 0,1 12,20M19.03,7.39L20.45,5.97C20,5.46 19.55,5 19.04,4.56L17.62,6C16.07,4.74 14.12,4 12,4A9,9 0 0,0 3,13A9,9 0 0,0 12,22C17,22 21,17.97 21,13C21,10.88 20.26,8.93 19.03,7.39M11,14H13V8H11M15,1H9V3H15V1Z\" /></svg><span class=\"card__time\"></span></div> </div><div class=\"card__img\" style=\"background-image:url(\"/img/backgroundgame/" + element.iconSrc + " \");\"></div><a href=/Home/Game/" + element.title + " class=\"card_link\"><div class=\"card__img--hover\"style=\"background-image:url(/Img/BackGroundGame/" + element.iconSrc + ");\"></div></a><div class=\"card__info\"><span class=\"card__category\"> GAMES 1st</span><h3 class=\"card__title\">" + element.name + "  <br>|</h3><span class=\"card__by\"><a href=/Home/Game/" + element.title +" class=\"card__author\" title=\"author\"><h3>" + element.price + "</h3></a></span></div></article>")
                });
            }
            else {
                $(".FindGamePage .main").append("<center><h1 style=\"color:red\">No Reslet</h1></center>");
            }
            $(".mainPageHome").addClass("Bablur");
            $(".FindGamePage").addClass("Show_FindPage");
            $("#body2").addClass("BodyShowFind");
        }
        else {
            alert("Must Enter Name Game");
        }
    }
)
function showMenu() {
    $("#menuUser").fadeToggle(1500);
}
$("#CloseFind").click(function () {
    $(".mainPageHome").removeClass("Bablur");
    $(".FindGamePage").removeClass("Show_FindPage");
    $("#body2").removeClass("BodyShowFind");
})
$("#serchGameText").keyup(function () {
    if ($("#serchGameText").val().length > 1) {
        $(".SuggestNameGames").show();
        var newSerch = lsData.filter(g => g.name.toUpperCase().includes($("#serchGameText").val().toUpperCase()));
        if (newSerch.length > 0) {
            $(".SuggestNameGames").empty();
            newSerch.forEach(element => {


                $(".SuggestNameGames").append
                    (
                        "<a href=/Home/Game/" + element.title +"><div class=\"gameSuggest\"><img src=\"/Img/BackGroundGame/" + element.iconSrc + "\"><p>|</p><h3>" + element.name + "</h3></div></a>"
                    );
            });
        }
        else {
            $(".SuggestNameGames").empty();
            $(".SuggestNameGames").append("<h1 style=\"color:white\">No elements</h1>")
        }


    }
    else {
        $(".SuggestNameGames").hide();
    }
});
$("#serchGameText").keydown(function () {
    if ($("#serchGameText").val().length > 1) {
        $(".SuggestNameGames").show();
        var newSerch = lsData.filter(g => g.name.toUpperCase().includes($("#serchGameText").val().toUpperCase()));
        if (newSerch.length > 0) {
            $(".SuggestNameGames").empty();
            newSerch.forEach(element => {
                $(".SuggestNameGames").append
                    (
                        "<a href=/Home/Game/" + element.title +"><div class=\"gameSuggest\"><img src=\"/Img/BackGroundGame/" + element.iconSrc + "\"><p>|</p><h3>" + element.name + "</h3></div></a>"
                    );
            });
        }
        else {
            $(".SuggestNameGames").empty();
            $(".SuggestNameGames").append("<h1 style=\"color:white\">No elements</h1>")
        }


    }
    else {
        $(".SuggestNameGames").hide();
    }
});
$("#RangeMenoy").click
    (
        function () {
            $("#RangeMenoyValue").text($("#RangeMenoy").val());
            if ($("#typeGameLs").val() == "all") {
                sercgGame = lsData.filter(g => g.name.toUpperCase().includes($("#serchGameText").val().toUpperCase()) && g.price <= $("#RangeMenoy").val());
            }
            else {
                sercgGame = lsData.filter(g => g.name.toUpperCase().includes($("#serchGameText").val().toUpperCase()) && g.price <= $("#RangeMenoy").val() && g.type == $("#typeGameLs").val());
            }
            $(".FindGamePage .main").empty();
            if (sercgGame.length > 0) {
                sercgGame.forEach(element => {
                    $(".FindGamePage .main").append("<article class=\"card card--1\" ><div class=\"card__info-hover\" ><svg class=\"card__like\"  viewBox=\"0 0 24 24\"><path fill=\"#000000\" d=\"M12.1,18.55L12,18.65L11.89,18.55C7.14,14.24 4,11.39 4,8.5C4,6.5 5.5,5 7.5,5C9.04,5 10.54,6 11.07,7.36H12.93C13.46,6 14.96,5 16.5,5C18.5,5 20,6.5 20,8.5C20,11.39 16.86,14.24 12.1,18.55M16.5,3C14.76,3 13.09,3.81 12,5.08C10.91,3.81 9.24,3 7.5,3C4.42,3 2,5.41 2,8.5C2,12.27 5.4,15.36 10.55,20.03L12,21.35L13.45,20.03C18.6,15.36 22,12.27 22,8.5C22,5.41 19.58,3 16.5,3Z\" /></svg><div class=\"card__clock-info\">  <svg class=\"card__clock\"  viewBox=\"0 0 24 24\"><path d=\"M12,20A7,7 0 0,1 5,13A7,7 0 0,1 12,6A7,7 0 0,1 19,13A7,7 0 0,1 12,20M19.03,7.39L20.45,5.97C20,5.46 19.55,5 19.04,4.56L17.62,6C16.07,4.74 14.12,4 12,4A9,9 0 0,0 3,13A9,9 0 0,0 12,22C17,22 21,17.97 21,13C21,10.88 20.26,8.93 19.03,7.39M11,14H13V8H11M15,1H9V3H15V1Z\" /></svg><span class=\"card__time\"></span></div> </div><div class=\"card__img\" style=\"background-image:url(/Img/BackGroundGame/" + element.iconSrc + ");\"></div><a href=/Home/Game/" + element.title + " class=\"card_link\"><div class=\"card__img--hover\"style=\"background-image:url(/Img/BackGroundGame/" + element.iconSrc + ");\"></div></a><div class=\"card__info\"><span class=\"card__category\"> GAMES 1st</span><h3 class=\"card__title\">" + element.name + "  <br>|</h3><span class=\"card__by\"><a href=/Home/Game/" + element.title +" class=\"card__author\" title=\"author\"><h3>" + element.price + "</h3></a></span></div></article>")
                });
            }
            else {
                $(".FindGamePage .main").append("<center><h1 style=\"color:red\">No Reslet</h1></center>");
            }
        }
    );
$("#typeGameLs").click
    (
        function () {

            if ($("#typeGameLs").val() == "all") {
                sercgGame = lsData.filter(g => g.name.toUpperCase().includes($("#serchGameText").val().toUpperCase()));
            }
            else {
                sercgGame = lsData.filter(g => g.name.toUpperCase().includes($("#serchGameText").val().toUpperCase()) && g.type == $("#typeGameLs").val());
            }
            $(".FindGamePage .main").empty();
            if (sercgGame.length > 0) {
                sercgGame.forEach(element => {
                    
                    $(".FindGamePage .main").append("<article class=\"card card--1\" ><div class=\"card__info-hover\" ><svg class=\"card__like\"  viewBox=\"0 0 24 24\"><path fill=\"#000000\" d=\"M12.1,18.55L12,18.65L11.89,18.55C7.14,14.24 4,11.39 4,8.5C4,6.5 5.5,5 7.5,5C9.04,5 10.54,6 11.07,7.36H12.93C13.46,6 14.96,5 16.5,5C18.5,5 20,6.5 20,8.5C20,11.39 16.86,14.24 12.1,18.55M16.5,3C14.76,3 13.09,3.81 12,5.08C10.91,3.81 9.24,3 7.5,3C4.42,3 2,5.41 2,8.5C2,12.27 5.4,15.36 10.55,20.03L12,21.35L13.45,20.03C18.6,15.36 22,12.27 22,8.5C22,5.41 19.58,3 16.5,3Z\" /></svg><div class=\"card__clock-info\">  <svg class=\"card__clock\"  viewBox=\"0 0 24 24\"><path d=\"M12,20A7,7 0 0,1 5,13A7,7 0 0,1 12,6A7,7 0 0,1 19,13A7,7 0 0,1 12,20M19.03,7.39L20.45,5.97C20,5.46 19.55,5 19.04,4.56L17.62,6C16.07,4.74 14.12,4 12,4A9,9 0 0,0 3,13A9,9 0 0,0 12,22C17,22 21,17.97 21,13C21,10.88 20.26,8.93 19.03,7.39M11,14H13V8H11M15,1H9V3H15V1Z\" /></svg><span class=\"card__time\"></span></div> </div><div class=\"card__img\" style=\"background-image:url(/Img/BackGroundGame/" + element.iconSrc + ");\"></div><a href=/Home/Game/" + element.title + " class=\"card_link\"><div class=\"card__img--hover\"style=\"background-image:url(/Img/BackGroundGame/" + element.iconSrc + ");\"></div></a><div class=\"card__info\"><span class=\"card__category\"> GAMES 1st</span><h3 class=\"card__title\">" + element.name + "  <br>|</h3><span class=\"card__by\"><a href=/Home/Game/" + element.title +" class=\"card__author\" title=\"author\"><h3>" + element.price + "</h3></a></span></div></article>")
                });
            }
            else {
                $(".FindGamePage .main").append("<center><h1 style=\"color:red\">No Reslet</h1></center>");
            }
        }
    );

//-------------------------------------------------------------------------
//Game
$(".SmallImages img").click(function () {
    var img1 = $(this).attr('src');
    var img2 = $(".BigImage img").attr('src');
    $(this).attr('src', img2);
    $(".BigImage img").attr('src', img1);
});
//like And DisLike
//--------------------
//like
$("#Likebtn").click(function () {
    $.post("/Home/AddLikeOrDisLikeGame", { TypeLike: "Like" });
    var num = Number($("#tLike").text()) + 1;
    $("#tLike").text(num);
    alert("Like");
});
//disLike
$("#DisLike").click(function () {
    $.post("/Home/AddLikeOrDisLikeGame", { TypeLike: "DLike" });
    var num = Number($("#TDisLike").text()) + 1;
    $("#TDisLike").text(num);
    alert("DisLike");
});
//--------------------
//comments
//--------------------------
$("#SendComment").click(function () {
    if ($("#commentcomment").val().length > 0) {
        $.post("/Home/Comments", { comment: $("#commentcomment").val() });
        var num = Number($("#NumerComents").text()) + 1;
        $("#NumerComents").text(num);
        alert("Save!")
    }
    else {
        alert("Must Enter Comment");
    }
});
//-------------------------------
//--------------------------------------------------------------
//Create Groubs----------------------------
//Create Groub CloseCreateGroub
//close
$("#CloseCreateGroub").click(function () {
    $("#CreateGroubDiv").hide();
    $(".mainPageHome").removeClass("Bablur2");
    $("#body2").removeClass("BodyShowFind");
})
//show
$("#CreateGurob").click(function () {
    $("#CreateGroubDiv").show();
    $(".mainPageHome").addClass("Bablur2");
    $("#body2").addClass("BodyShowFind");
})
      //end
//Password
function ShowChecked() {
    $("#Pass").fadeToggle();
    $("#PasswordChar").val("");
}
//end Password
//Show Pages Groub
//User
$("#MyGroubsP").click(function () {
    if ($("#MyGroubsP").val() == "Groubs") {
        $("#MyGroubsP").val("MyGroubs");
        $("#MyGroubsP").text("My Groubs");
        $("#Subscriver").hide();
        $("#NotSubscriver").show();
    }
    else {
        $("#MyGroubsP").val("Groubs");
        $("#MyGroubsP").text("Groubs");
        $("#Subscriver").show();
        $("#NotSubscriver").hide();
    }
});
//end
//End Frinds
$("#MyFrindsP").click(function () {
    if ($("#MyFrindsP").val() == "Frinds") {
        $("#MyFrindsP").val("MyFrinds");
        $("#MyFrindsP").text("My Frinds");
        $("#Subscriver").hide();
        $("#NotSubscriver").show();
    }
    else {
        $("#MyFrindsP").val("Frinds");
        $("#MyFrindsP").text("Frinds");
        $("#Subscriver").show();
        $("#NotSubscriver").hide();
    }
});
//end
$("#SwDwonPage").click(function () {
    $("#PagesS").slideToggle(2000);
});

