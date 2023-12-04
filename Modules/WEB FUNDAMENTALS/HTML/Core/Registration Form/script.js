let inputs = document.getElementsByTagName('input');
console.log(inputs)

for (let i = 0; i < inputs.length; i++) {
  const input = inputs[i];
  input.addEventListener('keyup', () => {
    if (!input.checkValidity()) {
      input.style.backgroundColor = '#75222380';
    } else if (input.value !== '') {
      input.style.backgroundColor = '#BCD5FF';
    } else {
      input.style.backgroundColor = '';
    }
  })
}

