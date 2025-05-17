import './App.css';
import CategoriesPage from "./pages/categories";
import {Route, Routes} from "react-router-dom";
import Layout from "./components/Layout";
import NoMatch from "./pages/NoMatch";

const App = () => {

    return (
        <>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<CategoriesPage />} />

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
