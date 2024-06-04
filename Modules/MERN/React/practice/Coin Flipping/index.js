function tossCoin() {
  return Math.random() > 0.5 ? 'heads' : 'tails';
}

function fiveHeads() {
  return new Promise( ( resolve, reject ) => {
    let attempts = 0;
    let heads = 0;
      
    while( heads < 20 ) {
      attempts++;
      let result = tossCoin();
      console.log(result)
      if ( result == 'heads' ) {
        heads++;
      }else {
        heads = 0;
      }
    } resolve(`It took ${attempts} attempts to flip heads 5 times`)
  });
}

fiveHeads()
  .then( res => console.log( res ) )
  .catch( err => console.log( err ) );

console.log( "When does this run now?" );  