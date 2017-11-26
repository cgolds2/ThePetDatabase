function createNode(element) {
      return document.createElement(element);
  }

  function append(parent, el) {
    return parent.appendChild(el);
  }

  const ul = document.getElementByPets('pets'); //?
  const url = '68.11.238.103:81/get_pets.php'; //url to PI call in database
  fetch(url)
  .then((resp) => resp.json())
  .then(function(data) {
    let pets = data.pets;
    return pets.map(function(pet) {
      let li = createNode('li'),
          img = createNode('img'),
          span = createNode('span');
      //img.src = pet.picture.medium;
      span.innerHTML = `${pet.name} ${pet.name}`;
      append(li, img);
      append(li, span);
      append(ul, li);
    })
  })
  .catch(function(error) {
    console.log(error);
  });   