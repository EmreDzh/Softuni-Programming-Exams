function solve() {
    let firstNameElement = document.getElementById('fname');
    let secondNameElement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let dateOfBirthElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');

    let tblBody = document.getElementById('tbody');

    let hireWorkerBUTTON = document.getElementById('add-worker');

    hireWorkerBUTTON.addEventListener('click', (e) =>{
       e.preventDefault();

       let salary = Number(salaryElement.value);

       if(firstNameElement.value === '' || secondNameElement.value === '' || emailElement.value === '' || dateOfBirthElement.value === '' || positionElement.value === '' || salaryElement.value === ''){
            
            firstNameElement.value = '';
            secondNameElement.value = '';
            emailElement.value = '';
            dateOfBirthElement.value = '';
            positionElement.value = '';
            salaryElement.value = '';      
   
        
            return; // clear the input fields here aswell
       }

       // new elements
       
       let TrEl = document.createElement('tr');
       let firstNameID = document.createElement('td');
       firstNameID.textContent = firstNameElement.value;
       let secondNameID = document.createElement('td');
       secondNameID.textContent = secondNameElement.value;
       let emailElementID = document.createElement('td');
       emailElementID.textContent = emailElement.value;
       let dateOfBirthID = document.createElement('td');
       dateOfBirthID.textContent = dateOfBirthElement.value;
       let positionID = document.createElement('td');
       positionID.textContent = positionElement.value;
       let salaryID = document.createElement('td');
       salaryID.textContent = salaryElement.value;

    

       let salarydas = document.getElementById('sum');
       let currentSum = Number(salarydas.textContent) + salary;
       salarydas.textContent = currentSum.toFixed(2);

       //buttons
       let buttonTD = document.createElement('td');

       let firedButton = document.createElement('button');
       firedButton.textContent = 'Fired';
       firedButton.classList.add('fired');
       firedButton.addEventListener('click', (e) =>{
        
        let currentSum = Number(salarydas.textContent) - salary;
        salarydas.textContent = currentSum.toFixed(2);
        
        TrEl.remove();
        
       });
       

       let editButton = document.createElement('button');
       editButton.textContent = 'Edit';
       editButton.classList.add('edit');
       editButton.addEventListener('click', (e) =>{  

        firstNameElement.value = firstNameID.textContent;
        secondNameElement.value = secondNameID.textContent;
        emailElement.value = emailElementID.textContent;
        dateOfBirthElement.value = dateOfBirthID.textContent;
        positionElement.value = positionID.textContent;
        salaryElement.value = salaryID.textContent;

        let currentSum = Number(salarydas.textContent) - salary;
        salarydas.textContent = currentSum.toFixed(2);
        
        TrEl.remove();
       });
       
       //appentthechildren
       TrEl.appendChild(firstNameID);
       TrEl.appendChild(secondNameID);
       TrEl.appendChild(emailElementID);
       TrEl.appendChild(dateOfBirthID);
       TrEl.appendChild(positionID);
       TrEl.appendChild(salaryID);

       buttonTD.appendChild(firedButton);
       buttonTD.appendChild(editButton);

       TrEl.appendChild(buttonTD);
       
       tblBody.appendChild(TrEl);

       firstNameElement.value = '';
       secondNameElement.value = '';
       emailElement.value = '';
       dateOfBirthElement.value = '';
       positionElement.value = '';
       salaryElement.value = '';      

    });
}
solve()