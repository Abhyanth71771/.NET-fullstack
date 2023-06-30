const note = {
    id: 1,
    title: 'My first note',
    date: '01/01/1970',
};

const result = Object.assign(note)
console.log("Id:"+result.id+"\nTitle is:"+result.title+"\nDate is:"+result.date)
