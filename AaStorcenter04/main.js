
//function getItemTable() {
//    let response = await fetch('api/itemtable');
//    let data = await response.json();
//    console.log(data);
//}

let userPoints = 100;

async function api(url) {
    const baseUrl = "API/";
    const res = await fetch(baseUrl + url);
    const data = await res.json();
    return data;
}

function renderCharities() {
    let cc = document.getElementById("cardcontainer");

    api("Charities").then(function (myJson) {
        console.log(myJson);

        for (var i = 0; i < myJson.length; i++) {
            let card = document.createElement("div");
            card.classList.add("card", "flex-row", "flex-wrap", "mb-4");

            let cardHeader = document.createElement("div");
            cardHeader.classList.add("card-header");

            let img = document.createElement("img");
            img.classList.add("card-img-top");
            img.id = "img" + i;
            img.src = "http://placehold.it/200x150";

            cardHeader.appendChild(img);

            let cb = document.createElement("div");
            cb.classList.add("card-block", "px-2");

            let cTitle = document.createElement("h5");
            cTitle.classList.add("card-title");
            cTitle.innerHTML = myJson[i].CharityName;

            let cDescription = document.createElement("p");
            cDescription.innerHTML = myJson[i].CharityDesc;

            let voteButton = document.createElement("button");
            voteButton.type = "button";
            voteButton.classList.add("btn", "btn-primary", "text-white");
            voteButton.setAttribute("data-toggle", "modal");
            voteButton.setAttribute("data-target", "#exampleModalCenter");

            voteButton.id = "charityID" + i;
            voteButton.innerHTML = "Donate";
            voteButton.onclick = function () { Donate(cTitle.innerHTML) };


            cb.appendChild(cTitle);
            cb.appendChild(cDescription);
            cb.appendChild(voteButton);

            card.appendChild(cardHeader);
            card.appendChild(cb);

            cc.appendChild(card);
        }
    })
        .then(function(){ replacePlaceholders(); });
    
            
}

function Donate(name) {
    val = document.getElementById("validationMessage")
    val.innerHTML = "";

    document.getElementById("modalInputForm").reset();

    let recepientField = document.getElementById("modalRecepient");
    recepientField.innerHTML = "<b>Recepient:</b> " + name.toString();

    let pointsField = document.getElementById("modalUserPoints");
    pointsField.innerHTML = "<b>Your total points:</b> " + userPoints.toString();

   
}

function validatePointsInput() {
    let x, text, color;
    x = document.getElementById("modalPointsInput").value;

    if (isNaN(x) || x < 1 || x > userPoints) {
        text = "Input not valid";
        document.getElementById("modalInputForm").reset();
    } else {
        userPoints = userPoints - x;
        text = "Success! " + x + " points were donated!";
        document.getElementById("modalInputForm").reset();
    }

    val = document.getElementById("validationMessage")
    val.innerHTML = text;

    let pointsField = document.getElementById("modalUserPoints");
    pointsField.innerHTML = "<b>Your total points:</b> " + userPoints.toString();

}

function renderVotings() {
    let cc = document.getElementById("cardcontainer");

    api("Votings").then(function (myJson) {
        console.log(myJson);

        for (var i = 0; i < myJson.length; i++) {
            let card = document.createElement("div");
            card.classList.add("card", "flex-row", "flex-wrap", "mb-4");

            let cardHeader = document.createElement("div");
            cardHeader.classList.add("card-header");

            let img = document.createElement("img");
            img.classList.add("card-img-top");
            img.src = "http://placehold.it/200x150";

            cardHeader.appendChild(img);

            let cb = document.createElement("div");
            cb.classList.add("card-block", "px-2");

            let cTitle = document.createElement("h5");
            cTitle.classList.add("card-title");
            cTitle.innerHTML = myJson[i].CharityName;

            let cDescription = document.createElement("p");
            cDescription.innerHTML = myJson[i].CharityDesc;

            let voteButton = document.createElement("button");
            voteButton.type = "button";
            voteButton.classList.add("btn", "btn-primary", "text-white");
            voteButton.setAttribute("data-toggle", "modal");
            voteButton.setAttribute("data-target", "#exampleModalCenter");

            voteButton.id = "charityID" + i;
            voteButton.innerHTML = "Donate";
            voteButton.onclick = function () { Donate(cTitle.innerHTML) };


            cb.appendChild(cTitle);
            cb.appendChild(cDescription);
            cb.appendChild(voteButton);

            card.appendChild(cardHeader);
            card.appendChild(cb);

            cc.appendChild(card);
        }
        
    });

}

function replacePlaceholders() {
    img0 = document.getElementById("img0");
    img1 = document.getElementById("img1");
    img2 = document.getElementById("img2");
    img0.src = "images/charity0.jpg";
    img1.src = "images/charity1.jpg";
    img2.src = "images/charity2.jpg";
}