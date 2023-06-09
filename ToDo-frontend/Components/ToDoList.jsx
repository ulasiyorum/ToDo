import Container from '@mui/material/Container';
import { Box, Button, IconButton, Input, List, ListItem, ListItemText, TextField } from '@mui/material';
import { useEffect, useRef, useState } from 'react';
import getToDosByUser, { addToDo, deleteToDo } from '../lib/todo';
import InteractiveList from './InteractiveList';
import EditIcon from '@mui/icons-material/Edit';
import FormDialog from './FormDialog';
import { rename } from '../lib/user';

export default function ToDoList({user}) {
    const [name,setName] = useState("");
    const [dialog,setDialog] = useState(false);
    const [list,setList] = useState(null);
    const [form,setForm] = useState({});
    useEffect(() => {

        async function fetchList() {
            const data = await getToDosByUser(user.id);
            if(data.success)
                setList(data.data);
        }
        fetchList();
    },[]);

    const onChangeForm = (event,type) => {
        setForm(() => {
            return {...form,[`${type}`]:event.target.value}
        });
    }
    const sendForm = async () => {
        await addToDo(form,user.id);
        const _list = await getToDosByUser(user.id);
        setList(_list.data);
    }

    const delToDo = async (index) => {
        await deleteToDo(list[index].id);
        const _list = await getToDosByUser(user.id);
        setList(_list.data);
    }
    const handleNameChange = async () => {
        await rename(name,user.id);
        setDialog(false);
    }
    return list ? (
        <Container sx={{width:'100vw',height:'100vh',display:'flex',justifyContent:'center',flexDirection:'column'}}>
            <FormDialog open={dialog} handleNameChange={handleNameChange} setName={setName} handleClose={() => setDialog(false)}/>
            <Box sx={{marginX:'auto'}}>Welcome {user.name}<IconButton onClick={() => setDialog(true)}>
                <EditIcon/>
                </IconButton></Box>
            {
                list.length == 0 ? (
                <Box sx={{marginX:'auto'}}>Nothing to show here..</Box>
                ) : (
                <ToDoComponent onDelete={delToDo} list={list}/>
                )
            }
            <Box sx={{marginX:'auto'}}>
                <TextField variant='outlined' onChange={(event) => onChangeForm(event,'title')} label='Title' sx={{width:'160px', marginX:'3px' ,marginY:'8px'}}/>
                <TextField variant='outlined' onChange={(event) => onChangeForm(event,'desc')} label='Description' sx={{width:'160px', marginX:'3px' ,marginY:'8px'}}/>
                <TextField variant='outlined' onChange={(event) => onChangeForm(event,'time')} label='Time (days)' sx={{width:'160px', marginX:'3px' ,marginY:'8px'}}/>
                <TextField variant='outlined' onChange={(event) => onChangeForm(event,'priority')} label='Priority' sx={{width:'160px', marginX:'3px' ,marginY:'8px'}}/>
            </Box>
            <Button variant='outlined' onClick={sendForm} sx={{width:'100px', marginX:'auto'}}>Add</Button>
        </Container>
    ) : (<div>Loading</div>);
}

function ToDoComponent(props){

    return (
        <Box sx={{marginX:'auto',marginY:'4px'}}>
            <InteractiveList list={props.list} onDelete={props.onDelete}/>
        </Box>
    );
}