function getCharities() {
    let response = await fetch('api/charities');
    let data = await response.json();
    console.log(data);
}

function getItemTable() {
    let response = await fetch('api/itemtable');
    let data = await response.json();
    console.log(data);
}