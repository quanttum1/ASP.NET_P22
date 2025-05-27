import './App.css';
import CategoriesPage from "./pages/categories";
import {Route, Routes} from "react-router-dom";
import Layout from "./components/Layout";
import NoMatch from "./pages/NoMatch";
import HomePage from "./pages/Home";
import CategoriesCreatePage from "./pages/categories/Create";
import Error500 from "./pages/Error500";
import LoginPage from "./pages/account/Login";
import {useAuthStore} from "./store/authStore";
import {jwtDecode} from "jwt-decode";
import {useEffect} from "react";

const App = () => {

    const { setUser } = useAuthStore((state) => state);

    useEffect(() => {
        const token = localStorage.getItem("jwt");
        if (token) {
            const decoded = jwtDecode(token);
            setUser(decoded);
        }
    },[]);


    return (
        <>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<HomePage />} />

                    <Route path={"categories"}>
                        <Route index element={<CategoriesPage />} />
                        <Route path={"create"} element={<CategoriesCreatePage />} />
                    </Route>

                    <Route path={"login"} element={<LoginPage/>}/>

                    <Route path="500" element={<Error500 />} />

                    {/* Using path="*"" means "match anything", so this route
                acts like a catch-all for URLs that we don't have explicit
                routes for. */}
                    <Route path="*" element={<NoMatch />} />
                </Route>
            </Routes>
        </>
    );
}

export default App;
