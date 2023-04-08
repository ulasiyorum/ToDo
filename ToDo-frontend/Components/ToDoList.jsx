import Container from '@mui/material/Container';
import { Box, Button, Input, TextField } from '@mui/material';
import { useEffect, useState } from 'react';
import getToDosByUser, { addToDo } from '../lib/todo';


export default function ToDoList({user}) {
    
    const [list,setList] = useState([]);
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
        setList(await getToDosByUser(user.id));
    }
    return (
        <Container sx={{width:'100vw',height:'100vh',display:'flex',justifyContent:'center',flexDirection:'column'}}>
            <Box sx={{marginX:'auto'}}>Welcome {user.name}</Box>
            {
                list.length == 0 ? (
                <Box sx={{marginX:'auto'}}>Nothing to show here..</Box>
                ) : (
                <Box>{list.length}</Box>
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
    );
}

function ToDoComponent(props){

}