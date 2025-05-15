import './App.css';
import {useEffect, useState} from "react";

const App = () => {



    //count - зберігає значення
    //setCount - функція для зміни значення
    const [count, setCount] = useState(0);

    useEffect(() => {
        axios.get(""):
        console.log('UseEffect APP', "Викликаємо після рендера");
    },[]);

    const [list, setList] = useState([])

    //Use State - вміє при зміни викликати render компонента в якому знаходиться
    console.log('Hello App', count);




    return (
        <>
            <h1>Привіт {count}</h1>
            <button onClick={() => {
                setCount(count + 1);
            }}>
                Назми мене
            </button>


            {list.length === 0 ? <h2>Список пустий</h2> :
                <table>
                    <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Image</th>
                    </tr>
                    </thead>
                    <tbody>
                    {
                        list.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.name}</td>
                                <td><img src={item.image} alt={item.name} width={75}/></td>
                            </tr>
                        ))
                    }
                    </tbody>
                </table>
            }
        </>
    );
}

export default App;
