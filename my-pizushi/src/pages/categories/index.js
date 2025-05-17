import {useEffect, useState} from "react";
import axios from "axios";
import {Link} from "react-router-dom";

const CategoriesPage = () => {

    const [list, setList] = useState([])

    useEffect(() => {
        axios.get("http://localhost:5186/api/Categories")
            .then(res => {
                const {data} = res;
                console.log("Get list of Categories", data);
                setList(data);
            })
            .catch(err => console.log("Problem", err));
        console.log('UseEffect APP', "Викликаємо після рендера");
    },[]);

    return (
        <>
            <h1 className={"text-center"}>Категорії</h1>
            <Link to={"create"} className={"btn btn-primary"}>Додати</Link>
            {list.length === 0 ? <h2>Список пустий</h2> :
                <table className="table">
                    <thead>
                    <tr>
                        <th>#</th>
                        <th>Назва</th>
                        <th>Image</th>
                    </tr>
                    </thead>
                    <tbody>
                    {
                        list.map((item) => (
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.name}</td>
                                <td><img src={`http://localhost:5186/images/200_${item.image}`} alt={item.name} width={75}/></td>
                            </tr>
                        ))
                    }
                    </tbody>
                </table>
            }
        </>
    )
}

export default CategoriesPage;