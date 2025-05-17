import {useState} from "react";
import axiosInstance from "../../../api/axiosInstance";
import {BASE_URL} from "../../../api/apiConfig";
import {useNavigate} from "react-router-dom";


const CategoriesCreatePage = () => {

    const [form, setForm] = useState({
        name: "",
        slug: "",
        imageFile: null,
    });

    const navigate = useNavigate();

    // const [errors, setErrors] = useState({})

    const onHandleChange = (e) => {
        setForm({...form, [e.target.name]: e.target.value});
    }

    const onHandleFileChange = (e) => {
        const files = e.target.files;
        if (files.length > 0) {
            setForm({...form, [e.target.name]: files[0]});
        }
        else {
            setForm({...form, [e.target.name]: null});
        }
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        // if(form.name === "") {
        //     setErrors({...errors, name: "Вкажіть назву"});
        // }
        // if(form.slug === "") {
        //     setErrors({...errors, slug: "Вкажіть назву"});
        // }
        try {
            var result = await axiosInstance.post(`${BASE_URL}/api/categories`, form,
                {
                    headers: {
                        "Content-Type": "multipart/form-data"
                    }
                });
            console.log("Server result", result);
            navigate("..");

        } catch(error) {
            console.error("Send request error", error);
        }
        // console.log("Submit data", form);
    }

    return (
        <>
            <h1 className={"text-center"}>Додати категорію</h1>
            <form onSubmit={handleSubmit} className={"col-md-6 offset-md-3"}>
                <div className="mb-3">
                    <label htmlFor="name" className="form-label">Назва</label>
                    <input type="text"
                           className="form-control"
                           name={"name"}
                           id="name"
                           value={form.name}
                           onChange={onHandleChange}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="slug" className="form-label">Url-Slug</label>
                    <input type="text"
                           className="form-control"
                           id="slug"
                           name={"slug"}
                           value={form.slug}
                           onChange={onHandleChange}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="imageFile" className="form-label">Оберіть фото</label>
                    <input type="file"
                           className="form-control"
                           id="imageFile"
                           name={"imageFile"}
                           onChange={onHandleFileChange}
                    />
                </div>
                <button type="submit" className="btn btn-primary">Додати</button>
            </form>
        </>
    )
}

export default CategoriesCreatePage