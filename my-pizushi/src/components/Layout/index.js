import {Link, NavLink, Outlet} from "react-router-dom";

const Layout = () => {
    return (
        <>
            {/* A "layout route" is a good place to put markup you want to
          share across all the pages on your site, like navigation. */}
            <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                <div className={"container"}>
                    <NavLink className="navbar-brand" to={"/"}>Admin Panel</NavLink>
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav"
                            aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            <li className="nav-item">
                                <NavLink to="/create" className={({ isActive }) => isActive ? 'nav-link active' : 'nav-link'}>Add Category</NavLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div className="container">
                <Outlet/>
            </div>

        </>
    );
}
export default Layout;
