import { Navigate, Outlet } from "react-router-dom";
import { useSelector } from "react-redux";
import {selectCurrentUser} from "../../store/selectors.ts";

const RequireAdmin = () => {
    const user = useSelector(selectCurrentUser);

    if (!user || !user.roles.includes("Admin")) {
        return <Navigate to="/login" replace />;
    }

    return <Outlet />;
};

export default RequireAdmin;
