import axios from "axios";

const baseUrl = "http://localhost:8004/";

const getAllToDo = (setTodo) => {
  axios.get(baseUrl).then(({data}) => {
    console.log(data);
    setTodo(data);
  });
};

const addToDo = (text, setText, setTodo) => {
  axios.post(`${baseUrl}save`, {text}).then((data) => {
    console.log(data);
    setText("");
    getAllToDo(setTodo);
  });
};

const updateToDo = (toDoId, text, setTodo, setText, setIsUpdating) => {
  axios
    .post(`${baseUrl}update`, {_id: toDoId, text})
    .then((data) => {
      console.log(data);
      setText("");
      setIsUpdating(false);
      getAllToDo(setTodo);
    })
    .catch((err) => console.log(err));
};

const deleteToDo = (_id, setTodo) => {
  axios
    .post(`${baseUrl}delete`, {_id})
    .then((data) => {
      getAllToDo(setTodo);
    })
    .catch((err) => console.log(err));
};

export {getAllToDo, addToDo, updateToDo, deleteToDo};
