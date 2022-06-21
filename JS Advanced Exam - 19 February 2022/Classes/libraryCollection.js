class LibraryCollection{
    constructor(capacity){
        this.capacity = Number(capacity);
        this.books = [];
    }

    addBook(bookName, bookAuthor){
        if(this.capacity <= this.books.length){
            throw new Error("Not enough space in the collection.");
        }

        let book = {
            bookName: bookName,
            bookAuthor: bookAuthor,
            payed: false,
        }

        this.books.push(book);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`


    }
    payBook(bookName){
        let findie = this.books.find(x => x.bookName == bookName);

        if(!findie){
            throw new Error(`${bookName} is not in the collection.`)
        }

        if(findie.payed === true){
            throw new Error(`${bookName} has already been paid.`);
        }

        findie.payed = true;

        return `${bookName} has been successfully paid.`;
    }
    removeBook(bookName){
        let findie = this.books.find(x => x.bookName == bookName);

        if(!findie){
            throw new Error(`The book, you're looking for, is not found.`);
        }
        if(findie.payed === false){
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books.splice(findie, 1);

        return `${bookName} remove from the collection.`;


    }
    getStatistics(bookAuthor){
        let returnie = [];
        if(bookAuthor == null){
            let emptySlots = Number(this.capacity - this.books.length);
            returnie.push(`The book collection has ${emptySlots} empty spots left.`)

            this.books.sort((a,b) => a.bookName.localeCompare(b.bookName)).forEach(x => {

                if(x.payed == false){
                    returnie.push(`${x.bookName} == ${x.bookAuthor} - Not Paid.`)
                }else{
                    returnie.push(`${x.bookName} == ${x.bookAuthor} - Has Paid.`)
                }
            });

            return returnie.join('\n');
        }else{
            let exists = this.books.find(x => x.bookAuthor == bookAuthor);

            if(!exists){
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            this.books.forEach(x => {
                if(x.payed == false){
                    returnie.push(`${x.bookName} == ${x.bookAuthor} - Not Paid.`)
                }else{
                    returnie.push(`${x.bookName} == ${x.bookAuthor} - Has Paid.`)
                }
                
            });

            return returnie.join('\n');
        }
    }
}

const library = new LibraryCollection(2)
console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
console.log(library.getStatistics('Miguel de Cervantes'));












